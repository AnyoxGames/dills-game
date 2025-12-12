13
3792456122369
404938659387424 1761863306777241200
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -14.7027788162231445,
    "Y": -12.1641759872436523
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404934724423239:1761863305860389800",
  "next_sibling": "404941592186212:1761863307460586800",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404938659850620:1761863306777347800",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404938660011182:1761863306777385200",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404938659850620:1761863306777347800",
    "DefaultRenderer": "404938660095075:1761863306777404900",
    "DepletedRenderer": "404938660066265:1761863306777398100"
  }
},
{
  "cid": 5,
  "aoid": "404938660033413:1761863306777390400",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
