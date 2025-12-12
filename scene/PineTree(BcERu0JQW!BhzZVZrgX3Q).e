13
3663607103489
404914195960854 1761863301077237200
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -15.0662269592285156,
    "Y": -7.0545377731323242
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404912050036027:1761863300577234900",
  "next_sibling": "404916484712219:1761863301610518400",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404914196333363:1761863301077323000",
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
  "aoid": "404914196508201:1761863301077363900",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404914196333363:1761863301077323000",
    "DefaultRenderer": "404914196599877:1761863301077385200",
    "DepletedRenderer": "404914196572959:1761863301077378800"
  }
},
{
  "cid": 5,
  "aoid": "404914196537527:1761863301077370600",
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
