13
3427383902209
404871277261252 1761863291077135800
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -16.1138153076171875,
    "Y": 7.5474839210510254
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404868344150154:1761863290393717900",
  "next_sibling": "404874710300326:1761863291877037300",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404871277516629:1761863291077194300",
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
  "aoid": "404871277650445:1761863291077225400",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404871277516629:1761863291077194300",
    "DefaultRenderer": "404871277701400:1761863291077237300",
    "DepletedRenderer": "404871277684286:1761863291077233300"
  }
},
{
  "cid": 5,
  "aoid": "404871277663431:1761863291077228500",
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
