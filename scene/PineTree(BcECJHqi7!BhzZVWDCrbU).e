13
3556232921089
404897457416379 1761863297177138900
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -16.6055355072021484,
    "Y": -1.1111090183258057
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404885726460111:1761863294443814000",
  "next_sibling": "404899532286478:1761863297660585900",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404897457674723:1761863297177198200",
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
  "aoid": "404897457800541:1761863297177227600",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404897457674723:1761863297177198200",
    "DefaultRenderer": "404897457850593:1761863297177239200",
    "DepletedRenderer": "404897457832576:1761863297177235000"
  }
},
{
  "cid": 5,
  "aoid": "404897457812280:1761863297177230200",
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
